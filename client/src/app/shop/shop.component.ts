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
  brandIdSelected: number = 0;
  typeIdSelected: number = 0;
  sortSelected = 'name';


  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts()
    this.getBrands()
    this.getTypes()
  }

  getProducts(){
    this.shopService.getProducts(this.brandIdSelected, this.typeIdSelected, this.sortSelected)
    .subscribe(response =>{
      this.products = response.data;
      console.log("Products uploaded")
    }, 
      error =>{
      console.log(error)
    });
  }

  getBrands(){
    return this.shopService.getBrands().subscribe(response =>{
      this.brands = [{id: 0, name: 'All'}, ...response];
      console.log("Brands uploaded")
    }
      ),
      error =>
      console.log(error);
  }

  getTypes(){
    return this.shopService.getTypes().subscribe(response =>{
      this.types = [{id: 0, name: 'All'}, ...response];
      console.log("Types uploaded")
    }
      ),
      error =>
      console.log(error);
  }

  onBrandSelected(brandId: number){
    this.brandIdSelected = brandId;
    this.getProducts();
  }

  onTypeSelected(typeId: number){
    this.typeIdSelected = typeId;
    this.getProducts();
  }

  onSortSelected(sort: string){

    switch(sort) { 
       case "Price: Low to High": { 
        this.sortSelected = "priceAsc"; 
          break; 
       }
       case "Price: High to Low": { 
        this.sortSelected = "priceDesc"; 
          break; 
       } 
       default: { 
        this.sortSelected = "name"; 
          break; 
       } 
    }
    console.log(sort);
    this.getProducts();
  }

}
