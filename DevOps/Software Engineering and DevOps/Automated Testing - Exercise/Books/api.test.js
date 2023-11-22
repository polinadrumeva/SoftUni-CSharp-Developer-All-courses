const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('./server');
const expect = chai.expect;

chai.use(chaiHttp);

//Verify Posting a Book
describe("Books API", () => {
    let bookId;
    it("should POST a book", (done) => {
        const book = {id: "1", title: "Test Book", author: "Test Author"};
        chai.request(server)
            .post("/books")
            .send(book)
            .end((err, res) => {
                expect(res).to.have.status(201);
                expect(res.body).to.be.a("object");
                expect(res.body).to.have.property("id");
                expect(res.body).to.have.property("title");
                expect(res.body).to.have.property("author");
                bookId = res.body.id;
                done();
            })
    });

    //Verify Getting All Books
    it("should GET all books", (done) => {
        chai.request(server)
            .get("/books")
            .end((err, res) => {
                expect(res).to.have.status(200);
                expect(res.body).to.be.a("array");
                done();
            })
    })

    //Verify Getting a Single Books
    it("should GET a single book", (done) => {
        const bookId = 1;
        chai.request(server)
            .get(`/books/${bookId}`)
            .end((err, res) => {
                expect(res).to.have.status(200);
                expect(res.body).to.be.a("object");
                expect(res.body).to.have.property("id");
                expect(res.body).to.have.property("title");
                expect(res.body).to.have.property("author");
                done();
            })
    });

    //Verify Updating a Book
    it("should PUT an existing book", (done) => {
        const bookId = 1;
        const book = {id: bookId, title: "Update Test Book", author: "Update Test Author"};
        chai.request(server)
            .put(`/books/${bookId}`)
            .send(book)
            .end((err, res) => {
                expect(res).to.have.status(200);
                expect(res.body).to.be.a("object");
                expect(res.body.title).to.equal("Update Test Book");
                expect(res.body.author).to.equal("Update Test Author");
                done();
            })
    });

    //Verify Deleting a Book
    it("should DELETE existing book", (done) => {
        
        chai.request(server)
            .delete(`/books/1`)
            .end((err, res) => {
                expect(res).to.have.status(204);
                done();
            });
    });

    //Verify Non-Existing Book
    it("should return 404 when trying to GET, PUT ot delete a non-existing book", (done) => {
        chai.request(server)
            .get(`/books/9999`)
            .end((err, res) => {
                expect(res).to.have.status(404);
              
            });
        chai.request(server)
            .put(`/books/9999`)
            .send({id: 9999, title: "Non-existing Book", author: "Non-existing Author"})
            .end((err, res) => {
                expect(res).to.have.status(404);
               
            });
        chai.request(server)
            .delete(`/books/9999`)
            .end((err, res) => {
                expect(res).to.have.status(404);
                done();
            });
    });

})