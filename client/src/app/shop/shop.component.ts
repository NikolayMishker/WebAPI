import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/brands';
import { IProduct } from '../shared/models/product';
import { IType } from '../shared/models/productType';
import { ShopService } from './shop.service';
import { ShopParams } from '../shared/models/shopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  @ViewChild('search', {static: true}) searchTerm: ElementRef
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  shopParams = new ShopParams();
  totalCount: number;

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts()
    this.getBrands()
    this.getTypes()
  }

  getProducts(){
    this.shopService.getProducts(this.shopParams)
    .subscribe(response =>{
      this.products = response.data;
      this.shopParams.pageNumber = response.pageIndex;
      this.shopParams.pageSize = response.pageSize;
      this.totalCount = response.count;
      console.log("Product count " + this.totalCount)
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
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: number){
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string){

    switch(sort) { 
       case "Price: Low to High": { 
        this.shopParams.sort = "priceAsc"; 
          break; 
       }
       case "Price: High to Low": { 
        this.shopParams.sort = "priceDesc"; 
          break; 
       } 
       default: { 
        this.shopParams.sort = "name"; 
          break; 
       } 
    }
    console.log(sort);
    this.getProducts();
  } 

  onPageChanged(event: any){
    if(this.shopParams.pageNumber !== event){
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch(){
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset(){
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }

}
