import { AfterViewInit, Component } from '@angular/core';
import { Chart } from 'chart.js';
import { HttpservicesService } from 'src/services/httpservices.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
})
export class MainComponent{
  trade: any;
  name: any;
  percent:any;
tradecount: any;
  constructor(private tradeservice: HttpservicesService) {
    this.name = sessionStorage.getItem('UserName');
    this.tradeservice.GetProfitCount(this.name).subscribe((data) => {
      this.trade = data;
      console.log(data);
    });

    this.tradeservice.GetTradeCount(this.name).subscribe((data)=>{
      this.tradecount=data;
    });

    this.tradeservice.ProfitPercent(this.name).subscribe((data)=>{
      this.percent=data;
    })
  }
 
}
