import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookstoreService } from '../../services/bookstore.service';

@Component({
  selector: 'app-bookstore-form',
  templateUrl: './bookstore-form.component.html',
  styleUrls: ['./bookstore-form.component.css']
})
export class BookstoreFormComponent implements OnInit {

  bookstore = {
    id:0.0
  };
  id: any;
  name: any;
  title: any;
  authorName: any;
  publisherName: any;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private bookstoreService: BookstoreService) {

      route.params.subscribe(p => {
        this.bookstore.id = +p['id'];
        }, err => {
          if (err.status == 404)
            this.router.navigate(['/bookstore']);
          });
  }

  ngOnInit() {
   let x: any = this.bookstoreService.getBookstore(this.bookstore.id)
      x.subscribe(b => {
        this.bookstore = b;
      });
  }
  submit() {
    if (!isNaN(this.bookstore.id)) {
      this.bookstoreService.update(this.bookstore)
        .subscribe(x => {
          console.log(x),
            this.router.navigate(['/bookstore'])
        });
    }
    else {
      this.bookstoreService.create(this.bookstore)
        .subscribe(x => {
          console.log(x),
            this.router.navigate(['/bookstore'])
        });
    }
  }
  delete() {
    if (confirm("Are you sure?")) {
      this.bookstoreService.delete(this.bookstore.id)
        .subscribe(x => {
          console.log(x),
            this.router.navigate(['/bookstore'])
        });
    }
  }

}
/*import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bookstore-form',
  templateUrl: './bookstore-form.component.html',
  styleUrls: ['./bookstore-form.component.css']
})
export class BookstoreFormComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
*/
