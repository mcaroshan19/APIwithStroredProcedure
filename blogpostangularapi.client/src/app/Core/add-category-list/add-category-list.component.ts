import { Component ,OnInit} from '@angular/core';
import { ServiceService } from '../../service.service';
import { RequestModel } from '../Model/request-model';
import { FormsModule } from '@angular/forms';
import { NgForm } from '@angular/forms'; 
import { ResponseModel } from '../Model/response-model';
import { SharedService } from './Services/shared.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-category-list',
  templateUrl: './add-category-list.component.html',
  styleUrl: './add-category-list.component.css'
})
export class AddCategoryListComponent implements OnInit {
 
  userData: ResponseModel[] = [];

 
  constructor(private serviceService: ServiceService,
    private sharedService: SharedService,
    private router: Router) {}
  ngOnInit(): void {
    this.getApi();
  }

  //set data
  onEdit(item:ResponseModel) {
    
    this.router.navigate(['/add-category'],{ state: { data: item } });
  }
  // onEdit(): void {
  //   if (this.hero) {
  //     this.serviceService.updateHero(this.hero)
  //       .subscribe(() => this.goBack());
  //   }
  // }



//get data to api
  getApi(): void {
    this.serviceService.getSuperHeroes().subscribe(data => {
      console.log('Data received from API:', data);
      this.userData = data;
      console.log('Assigned userData:', this.userData);
    }, (error) => {
      console.error('Error fetching data', error);
    });
  }

}
