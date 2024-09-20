import { Component } from '@angular/core';
import { NgForm } from '@angular/forms'; // Correct import for NgForm
import { SharedService } from '../add-category-list/Services/shared.service';
import { RequestModel } from '../Model/request-model'; // Ensure correct model import
import { FormsModule } from '@angular/forms';

import { AddcategoryPService } from '../add-category-list/Services/addcategory-p.service';
@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css'] // Correct property name for styleUrls
})
export class AddCategoryComponent  {
 
 
  constructor(
    private addcategoryPService: AddcategoryPService,
    private sharedService: SharedService,
     
     
     ) {}


    



 //Post API
  onFormSubmit(data:any){
   
    this.addcategoryPService.addCategory(data).subscribe((result)=>{
      console.warn(result);

    }
    
    );
  }
  

  
 
  }

