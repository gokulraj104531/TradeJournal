import {  Component, OnInit } from '@angular/core';
declare const TradingView: any;
@Component({
  selector: 'app-charts',
  templateUrl: './charts.component.html',
  styleUrls: ['./charts.component.css'],
})
export class ChartsComponent implements OnInit {
  ngOnInit() {
    new TradingView.widget({
      width: 920,
      height: 575,
      symbol: 'OANDA:EURUSD',
      interval: '60',
      timezone: 'Etc/UTC',
      theme: 'light',
      style: '1',
      locale: 'en',
      toolbar_bg: '#f1f3f6',
      enable_publishing: false,
      withdateranges: true,
      hide_side_toolbar: false,
      allow_symbol_change: true,
      watchlist: [
        'OANDA:EURUSD',
        'OANDA:GBPUSD',
        'OANDA:USDJPY',
        'OANDA:USDCAD',
        'OANDA:USDCHF',
        'OANDA:AUDUSD',
        'OANDA:NZDUSD',
        'OANDA:EURJPY',
        'OANDA:GBPJPY',
        'OANDA:NZDJPY',
        'OANDA:CADJPY',
        'OANDA:AUDJPY',
      ],
      details: true,
      calendar: false,
      container_id: 'tradingview_bac65',
    });
  }
}
