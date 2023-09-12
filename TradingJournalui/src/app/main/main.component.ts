import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { Chart } from 'chart.js';
import { Subscription } from 'rxjs';
import { ProfitorLoss } from 'src/models/ProfitorLoss';
import { HttpservicesService } from 'src/services/httpservices.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
})
export class MainComponent implements  OnDestroy,OnInit{
  trade: any;
  name: any;
  percent: any;
  tradecount: any;
  profitCount!: Subscription;
  tradeCount!: Subscription;
  profitPercent!: Subscription;
  public lineChartLabels: string[] = [];
  public lineChartData: any[] = [{ data: [], label: 'Profits/Losses' ,borderColor: 'blue', pointBackgroundColor: []}];
  public lineChartOptions: any = {
    responsive: true,
    // scales: {
    //   x: [{
    //     ticks: {
    //       display: true,
    //     },
    //   }],
    //   y: [{
    //     ticks: {
    //       beginAtZero: true,
    //     },
    //   }],
    // },
    // plugins: {
    //   legend: {
    //     position: 'top',
    //   },
    // },
    // chart: {
    //   type: 'line',
    // },
  };


  public lineChartType = 'line'; 
  constructor(private tradeservice: HttpservicesService) {
    this.name = sessionStorage.getItem('UserName');
    this.profitCount = this.tradeservice
      .GetProfitCount(this.name)
      .subscribe((data) => {
        this.trade = data;
      });

    this.tradeCount = this.tradeservice
      .GetTradeCount(this.name)
      .subscribe((data) => {
        this.tradecount = data;
      });

    this.profitPercent = this.tradeservice
      .ProfitPercent(this.name)
      .subscribe((data) => {
        this.percent = data;
      });
  }
  ngOnInit(){
   
    this.tradeservice.Linechart(this.name).subscribe((response:ProfitorLoss[]) => {
      const profitorLossData: number[] = response.map(item => item.profitorLoss);
      this.lineChartLabels = profitorLossData.map((_, index) => `${index + 1}`);
      this.lineChartData[0].data = profitorLossData;
    });
  }
  ngOnDestroy(): void {
    this.tradeCount.unsubscribe();
    this.profitPercent.unsubscribe();
    this.profitCount.unsubscribe();
  }
  
}
