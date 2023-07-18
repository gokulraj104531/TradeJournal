import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
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
      StockName: new FormControl ('',Validators.required),
      OrderType: new FormControl ('',Validators.required),
      Quantity: new FormControl ('',Validators.required),
      EntryPrice: new FormControl ('',Validators.required),
      EntryTime: new FormControl ('',Validators.required),
      ClosePrice:new FormControl ('',Validators.required),
      CloseTime:new FormControl ('',Validators.required),
      ProfitorLoss: new FormControl ('',Validators.required),
      JournalTrade: new FormControl ('',Validators.required)
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
