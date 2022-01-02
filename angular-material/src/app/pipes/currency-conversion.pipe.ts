import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'currencyConversion'
})
export class CurrencyConversionPipe implements PipeTransform {

  transform(priceInRon: number, currency: String): String {

    var price = priceInRon;

    if (currency == "EUR") {
      price /= 5;
      return "~" + price + " " + currency;
    }

    return price + " " + currency;
  }

}
