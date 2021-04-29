import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CarDto } from 'app/models/carDto';
import { CarImage } from 'app/models/carImage';
import { CarService } from 'app/services/car.service';
import { environment } from 'environments/environment';

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.css']
})
export class CarDetailComponent implements OnInit {
  car:CarDto;
  dataLoaded = false;
  subTitle:string = "";
  images:CarImage[];
  imageUrl = environment.baseURL;
  model: any;
  currentImage:CarImage;
  
  constructor(private carService:CarService,
    private activatedRoute:ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["carId"]){
        this.getCarById(params["carId"]);
      }else{
        this.getCars();
      }
    });
  }

  getCars(){
    this.router.navigate(['/cars']);
  }

  getCarById(carId:number){
    this.carService.getCarDetailsById(carId).subscribe(response=>{
      this.car = response.data;
      this.images = this.car.images;
      this.subTitle = "";
      this.dataLoaded = true;
    });
  }


  getSlideClass(index:Number){
    if(index == 0){
      return "carousel-item text-center active";
    } else {
      return "carousel-item text-center";
    }
  }
  getSlideNumber(index:Number){
    return index.toString();
  }

  setCurrentProject(image: CarImage) {
    this.currentImage = image;
  }

  getCurrentProjectclass(image: CarImage) {
    if (image == this.currentImage) {
      return 'active';
    } else {
      return '';
    }
  }

}
