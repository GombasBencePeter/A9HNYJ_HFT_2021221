let authors = [];


fetch('http://localhost:37921/admin/Author')
    .then(x => x.json())
    .then(y => {
        authors = y;
        display();
    })
    ;



function display() {
    authors.forEach(x => {
        document.getElementById('authorTable').innerHTML += "<tr><td>" + x.authorKey + "</td>" +
            "<td>" + x.authorName + "</td>" +
            "<td>" + x.forKids + "</td>" +
            "<td>" + x.isActive + "</td>" +
            "<td>" + x.originalLanguage + "</td>" +
            "<td>" + x.yearBorn + "</td></tr>";
    });
}