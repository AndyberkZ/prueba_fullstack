import { Component, OnInit } from '@angular/core';
import { ProductsService } from './../products.service';
@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {
  producto = {
    Nombre: '',
    Precio: 0.00,
    Stock: 0,
    FechaRegistro: ''
  };
  submitted = false;
  constructor(private productsService: ProductsService) { }

  ngOnInit(): void {
  }

  saveProducto(): void {
    const data = {
      Nombre: this.producto.Nombre,
      Precio: this.producto.Precio,
      Stock: this.producto.Stock,
      FechaRegistro: this.producto.FechaRegistro
    };

    this.productsService.Create(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newProducto(): void {
    this.submitted = false;
    this.producto = {
      Nombre: '',
    Precio: 0.00,
    Stock: 0,
    FechaRegistro: ''
    };
  }
}
