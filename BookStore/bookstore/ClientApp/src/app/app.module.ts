import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule} from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BookstoreFormComponent } from './components/bookstore-form/bookstore-form.component';
import { BookstoreListComponent } from './components/bookstore-list/bookstore-list.component';
import { BookstoreService } from './services/bookstore.service';
import { APP_BASE_HREF } from '@angular/common';
import { HttpModule } from '@angular/http';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    BookstoreFormComponent,
    BookstoreListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule, HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'bookstore', pathMatch: 'full' },
      { path: 'bookstore/new', component: BookstoreFormComponent },
      { path: 'bookstore/:id', component: BookstoreFormComponent },
      { path: 'bookstore', component: BookstoreListComponent },
      { path: 'home', component: HomeComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: '**', redirectTo: 'home' }
    ])
  ],
  providers: [
    { provide: APP_BASE_HREF, useValue: '/' },
    BookstoreService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
