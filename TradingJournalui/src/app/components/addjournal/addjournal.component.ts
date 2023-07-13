import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Journal } from 'src/models/Journal';
import { HttpservicesService } from 'src/services/httpservices.service';

@Component({
  selector: 'app-addjournal',
  templateUrl: './addjournal.component.html',
  styleUrls: ['./addjournal.component.css'],
})
export class AddjournalComponent {
  tradearray: Journal[] = [];
  tradeformgroup: FormGroup;
  name:any;
  constructor(
    private tradeservice: HttpservicesService,
    private route: Router,
    private trade: FormBuilder
  ) {
this.name=sessionStorage.getItem("UserName");

    this.tradeformgroup = this.trade.group({
      journalId:[0],
      UserName:[this.name],
      StockName: [''],
      OrderType: [''],
      Quantity: [''],
      EntryPrice: [''],
      EntryTime: [''],
      ClosePrice: [''],
      CloseTime:[''],
      ProfitorLoss: [''],
      JournalTrade: [''],
    });
  }
  onSubmit() {
    this.tradeservice
      .AddTrade(this.tradeformgroup.value)
      .subscribe((response) => {
        console.log(response);
        this.tradeformgroup.setValue({
          journalId:'',
          UserName:'',
          StockName: '',
          OrderType: '',
          Quantity: '',
          EntryPrice: '',
          EntryTime: '',
          ClosePrice: '',
          CloseTime:'',
          ProfitorLoss: '',
          JournalTrade: '',
        });
        this.route.navigateByUrl('/viewjournal');
      },(err)=>{
        console.warn("Error");
      });
  }
}
