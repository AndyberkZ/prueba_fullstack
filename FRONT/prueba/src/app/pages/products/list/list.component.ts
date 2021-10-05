import { Component, OnInit } from '@angular/core';
import { ProductsService } from './../products.service';
import { NavigationExtras, Router } from '@angular/router';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  productos: any;
  currentProducto : any;
  currentIndex = -1;
  title = '';
  constructor(private productsSvc: ProductsService) { }

  ngOnInit(): void {
    this.GetAll();
  }
  GetAll(): void {
    this.productsSvc.GetAll()
      .subscribe(
        data => {
          this.productos = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  refreshList(): void {
    this.GetAll();
    this.currentProducto = null;
    this.currentIndex = -1;
  }

  setActiveTutorial(producto:any, index:any): void {
    this.currentProducto = producto;
    this.currentIndex = index;
  }

  removeAllProducto(id:any): void {
    this.productsSvc.Delete(id)
      .subscribe(
        response => {
          console.log(response);
          this.GetAll();
        },
        error => {
          console.log(error);
        });
  }

  searchTitle(): void {
    this.productsSvc.GetById(this.title)
      .subscribe(
        data => {
          this.productos = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }
}
