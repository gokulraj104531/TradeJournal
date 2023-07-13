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
  tradearray: Journal[] = [];
  constructor(private tradeservice: HttpservicesService) {

   this.tradeservice.GetTrade().subscribe((data)=>
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
