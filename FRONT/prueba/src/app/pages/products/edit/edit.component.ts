import { Component, OnInit } from '@angular/core';
import { ProductsService } from './../products.service';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  currentProducto : any;
  id : any;
  message = '';
  constructor(private productsService: ProductsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.id = this.route.snapshot.paramMap.get('id');
    this.getGetId(this.route.snapshot.paramMap.get('id'));
  }

  getGetId(id:any): void {
    this.productsService.GetById(id)
      .subscribe(
        data => {
          this.currentProducto = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }



  updateProducto(): void {
    this.currentProducto.Id = this.id;
    this.productsService.Update(this.currentProducto)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The tutorial was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }

  deleteProducto(): void {
    this.productsService.Delete(this.id)
      .subscribe(
        response => {
          console.log(response);
          this.router.navigate(['/list']);
        },
        error => {
          console.log(error);
        });
  }
}
