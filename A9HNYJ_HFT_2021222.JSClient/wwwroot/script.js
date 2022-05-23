
let books = [];
let booksWithNewerEditions = [];
let connection = null;
refresh()
setupSignalR();

function setupSignalR() {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:37921/admin/hub")
    .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BookCreated", (user, message) => {
        getdata();
    });

    connection.on("BookDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};


function refresh() {
    
    fetch('http://localhost:37921/admin/Book')
        .then(x => x.json())
        .then(y => {
            
            books = y;
            display();
        })
        ;
}

function remove(id) {
    fetch('http://localhost:37921/admin/Book/' +id, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
        },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            refresh();
        })
        .catch((error) => {
            console.error('Error:', error);
        })
}

function updateActivator(id) {
    document.getElementById('bookID').disabled = false;
    document.getElementById('updateButton').disabled = false;

    let bookToUpdate = books.find(x => x[`bookID`] == id);
    document.getElementById('bookID').value = bookToUpdate.bookID;
    document.getElementById('authorID').value = bookToUpdate.authorID;
    document.getElementById('publisherID').value = bookToUpdate.publisherID;
    document.getElementById('bookName').value = bookToUpdate.bookname;
    document.getElementById('price').value = bookToUpdate.price;
    document.getElementById('supply').value = bookToUpdate.supply;
    document.getElementById('year').value = bookToUpdate.year;
}

function update() {
    let bookID = document.getElementById('bookID').value;
    let authorID = document.getElementById('authorID').value;
    let publisherID = document.getElementById('publisherID').value;
    let bookname = document.getElementById('bookName').value;
    let price = document.getElementById('price').value;
    let supply = document.getElementById('supply').value;
    let year = document.getElementById('year').value;
    fetch('http://localhost:37921/admin/Book', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                bookID: bookID,
                authorID: authorID,
                publisherID: publisherID,
                bookname: bookname,
                price: price,
                supply: supply,
                year: year
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            refresh();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    document.getElementById('bookID').disabled = true;
    document.getElementById('updateButton').disabled = true;

    document.getElementById('bookID').value = "";
    document.getElementById('authorID').value = "";
    document.getElementById('publisherID').value = "";
    document.getElementById('bookName').value = "";
    document.getElementById('price').value = "";
    document.getElementById('supply').value = "";
    document.getElementById('year').value = "";
    refresh();
}

function display() {
    document.getElementById('bookTable').innerHTML = "";
    books.forEach(x => {
        document.getElementById('bookTable').innerHTML += "<tr><td>" + x.bookID + "</td>" +
            "<td>" + x.authorID + "</td>" +
            "<td>" + x.publisherID + "</td>" +
            "<td>" + x.bookname + "</td>" +
            "<td>" + x.price + "</td>" +
            "<td>" + x.supply + "</td>" +
            "<td>" + x.year + "</td>" +
            "<td>" + `<button type="button" onclick="remove(${x.bookID})"> Delete </button>`+
            `<button type="button" onclick="updateActivator(${x.bookID})"> Update </button>` + "</td></tr>";
    });
}

function create() {
    let authorID = document.getElementById('authorID').value;
    let publisherID = document.getElementById('publisherID').value;
    let bookname = document.getElementById('bookName').value;
    let price = document.getElementById('price').value;
    let supply = document.getElementById('supply').value;
    let year = document.getElementById('year').value;
    fetch('http://localhost:37921/admin/Book', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                
                authorID: authorID,
                publisherID: publisherID,
                bookname: bookname,
                price: price,
                supply: supply,
                year: year
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            refresh();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
    
}

function booksWithNewEditions() {

    document.getElementById('bookneweditionsTable').innerHTML = "";
    fetch('http://localhost:37921/User/Book/withneweditions')
        .then(x => x.json())
        .then(y => {
            booksWithNewerEditions = y;
        })

    
    booksWithNewerEditions.forEach(p => {
        document.getElementById('bookneweditionsTable').innerHTML += "<tr><td>" + p.bookID + "</td>" +
            "<td>" + p.authorID + "</td>" +
            "<td>" + p.publisherID + "</td>" +
            "<td>" + p.bookname + "</td>" +
            "<td>" + p.price + "</td>" +
            "<td>" + p.supply + "</td>" +
            "<td>" + p.year + "</td>" + "</td></tr>";
    });
}