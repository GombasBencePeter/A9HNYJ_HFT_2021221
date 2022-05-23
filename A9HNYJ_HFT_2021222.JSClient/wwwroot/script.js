let books = [];

refresh()

function refresh() {
    fetch('http://localhost:37921/admin/Book')
        .then(x => x.json())
        .then(y => {
            books = y;
            console.log(y);
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

function display() {
    books.forEach(x => {
        document.getElementById('bookTable').innerHTML += "<tr><td>" + x.bookID + "</td>" +
            "<td>" + x.authorID + "</td>" +
            "<td>" + x.publisherID + "</td>" +
            "<td>" + x.bookname + "</td>" +
            "<td>" + x.price + "</td>" +
            "<td>" + x.supply + "</td>" +
            "<td>" + x.year + "</td>" +
            "<td>" + `<button type="button" onclick="remove(${x.bookID})"> Delete </button>` + "</td></tr>";
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