import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

  transform(value: any[], filterString: string, tourName: string): any[] {
    const resultArray = [];
    if (value){
      if (value.length === 0 || filterString === '' || tourName === '') {
          return value;
      }

      for (const item of value) {
          if (item[tourName] === filterString) {
              resultArray.push(item);
          }
      }
    }
    return resultArray;
  }
}
