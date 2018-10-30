import { Component, OnInit } from '@angular/core';
import { BookstoreService } from '../../services/bookstore.service';

@Component({
  selector: 'app-bookstore-list',
  templateUrl: './bookstore-list.component.html',
  styleUrls: ['./bookstore-list.component.css']
})
export class BookstoreListComponent implements OnInit {
  bookstores: any[];
  constructor(private bookstoreService: BookstoreService) { }

  ngOnInit() {
    this.bookstoreService.getBookstores()
      .subscribe(bookstores => this.bookstores = bookstores);
  }

}
