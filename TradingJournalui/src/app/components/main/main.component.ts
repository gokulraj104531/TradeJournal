import { AfterViewInit, Component } from '@angular/core';
import { Chart } from 'chart.js';
import { HttpservicesService } from 'src/services/httpservices.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css'],
})
export class MainComponent implements AfterViewInit{
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
  ngAfterViewInit(): void {
    this.createChart();
  }
  createChart() {
    const ctx = document.getElementById('myChart') as HTMLCanvasElement;
    const myChart = new Chart(ctx, {
      type: 'line',
      data: {
        labels: ['January', 'February', 'March', 'April', 'May', 'June'],
        datasets: [{
          label: 'My Dataset',
          data: [10, 20, 30, 40, 50, 60],
          fill: false,
          borderColor: 'rgb(75, 192, 192)',
          tension: 0.1
        }]
      },
      options: {
        scales: {
          y: {
            beginAtZero: true
          }
        }
      }
    });
  }
}
