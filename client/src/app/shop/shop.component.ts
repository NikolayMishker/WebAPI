import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/brands';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products: IProduct[];
  brands: IBrand[];
  types: IType[];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts()
    this.getBrands()
    this.getTypes()
  }

  getProducts(){
    this.shopService.getProducts().subscribe(response =>{
      this.products = response.data;
      console.log("Products uploaded")
    }, 
      error =>{
      console.log(error)
    });
  }

  getBrands(){
    return this.shopService.getBrands().subscribe(responce =>{
      this.brands = responce;
      console.log("Brands uploaded")
    }
      ),
      error =>
      console.log(error);
  }

  getTypes(){
    return this.shopService.getTypes().subscribe(responce =>{
      this.types = responce;
      console.log("Types uploaded")
    }
      ),
      error =>
      console.log(error);
  }

}
