import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class BookstoreService {
  constructor(private http: Http) { }
  create(bookstore: any) {
    let data: Book = {
      name: bookstore.name,
      title: bookstore.title,
      authorName: bookstore.authorName,
      publisherName: bookstore.publisherName
    };
    return this.http.post('/api/bookstores', data)
      .map(res => res.json());
  }
  getBookstore(id:any){
    return this.http.get('/api/bookstores/' + id)
      .map(res => res.json());
  }
  update(bookstore: any) {
    let data: Bookstore = bookstore;
    return this.http.put('/api/bookstores/' + bookstore.id, data)
      .map(res => res.json());
  }
  delete(id:any){
    return this.http.delete('/api/bookstores/' + id)
      .map(res => res.json());
  }
  getBookstores()
  {
    return this.http.get('/api/bookstores')
      .map(res => res.json());
  }
}
class Bookstore {
   id: any; 
   name: any;
   title: any;
   authorName: any;
   publisherName: any
}
class Book {
  name: any;
  title: any;
  authorName: any;
  publisherName: any
}
