import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Journal } from 'src/models/Journal';
import { HttpservicesService } from 'src/services/httpservices.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-addjournal',
  templateUrl: './addjournal.component.html',
  styleUrls: ['./addjournal.component.css'],
})
export class AddjournalComponent implements OnInit {
  tradearray: Journal[] = [];
  tradeformgroup?: FormGroup;
  name: any;

  constructor(
    private tradeservice: HttpservicesService,
    private route: Router,
    private trade: FormBuilder,
    private arouter: ActivatedRoute
  ) {
    this.name = sessionStorage.getItem('UserName');

    this.checkParam();
  }

  ngOnInit(): void {
    console.log("value" , this.arouter.snapshot.params['journalId']);
    this.initForm();
  }

  checkParam() {
    if (this.arouter.snapshot.params['journalId'] != null) {
      let paramsvalue = this.arouter.snapshot.params['journalId']!;
      this.tradeformgroup?.get('journalId')?.setValue(paramsvalue);
      this.tradeservice.GetJournalById(paramsvalue).subscribe((response) => {
        let data = response;
        let dataedit = data[0];
        //console.log('resp:', dataedit);

        if (response != null) {
          this.tradeformgroup?.setValue({
            journalId: dataedit.journalId,
            UserName: dataedit.userName,
            StockName: dataedit.stockName,
            OrderType: dataedit.orderType,
            Quantity: dataedit.quantity,
            EntryPrice: dataedit.entryPrice,
            EntryTime: dataedit.entryTime,
            ClosePrice: dataedit.closePrice,
            CloseTime: dataedit.closeTime,
            ProfitorLoss: dataedit.profitorLoss,
            JournalTrade: dataedit.journalTrade,
          });
        }
      });
      console.log('value:', this.tradeformgroup?.value);
    } else {
      console.log('Editid is null');
    }
  }

  initForm() {
    this.tradeformgroup = this.trade.group({
      journalId: new FormControl(0),
      UserName: new FormControl(this.name, Validators.required),
      StockName: new FormControl('', Validators.required),
      OrderType: new FormControl('', Validators.required),
      Quantity: new FormControl('', Validators.required),
      EntryPrice: new FormControl('', Validators.required),
      EntryTime: new FormControl('', Validators.required),
      ClosePrice: new FormControl('', Validators.required),
      CloseTime: new FormControl('', Validators.required),
      ProfitorLoss: new FormControl('', Validators.required),
      JournalTrade: new FormControl('', Validators.required),
    });
  }

  onSubmit() {
    
    if (
      // this.tradeformgroup?.value.journalId != null &&
      this.tradeformgroup?.value.journalId != 0
    ) {
      console.log(this.tradeformgroup?.value.journalId);
      this.tradeservice
        .EditTrade(this.tradeformgroup?.value)
        .subscribe((response) => {
          this.tradeformgroup?.setValue({
            journalId: '',
            UserName: '',
            StockName: '',
            OrderType: '',
            Quantity: '',
            EntryPrice: '',
            EntryTime: '',
            ClosePrice: '',
            CloseTime: '',
            ProfitorLoss: '',
            JournalTrade: '',
          });
          this.route.navigateByUrl('/viewjournal');
        });
    } else {
      this.tradeservice.AddTrade(this.tradeformgroup?.value).subscribe(
        (response) => {
          console.log(response);
          this.tradeformgroup?.setValue({
            journalId: '',
            UserName: '',
            StockName: '',
            OrderType: '',
            Quantity: '',
            EntryPrice: '',
            EntryTime: '',
            ClosePrice: '',
            CloseTime: '',
            ProfitorLoss: '',
            JournalTrade: '',
          });
          this.route.navigateByUrl('/viewjournal');
        },
        (err) => {
          //console.warn(this.tradeformgroup?.value)
          console.warn('Error');
        }
      );
    }
  }
}
