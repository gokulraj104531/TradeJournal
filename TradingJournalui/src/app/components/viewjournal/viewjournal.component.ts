import { Component, NgZoneOptions, OnInit } from '@angular/core';
import { Journal } from 'src/models/Journal';
import { HttpservicesService } from 'src/services/httpservices.service';

@Component({
  selector: 'app-viewjournal',
  templateUrl: './viewjournal.component.html',
  styleUrls: ['./viewjournal.component.css']
})
export class ViewjournalComponent{
trade:any;
nameid:any;
  tradearray: Journal[] = [];
  constructor(private tradeservice: HttpservicesService) {
    this.nameid=sessionStorage.getItem("UserName")
   this.tradeservice.GetTrade(this.nameid).subscribe((data)=>
    {
      this.trade=data
      console.log(this.trade)
    });
   
    // gettrade(){
    //   this.tradeservice.GetTrade().subscribe((response) => {
    //     console.log(response);
    //     this.tradearray = response;
    //   })
    // }
  }

  
}
