import { Pipe, PipeTransform } from '@angular/core';
@Pipe({
  name: 'phoneFormat',
  standalone: true
})
export class PhoneFormatPipe implements PipeTransform {
  transform(value: string): string {
  if (!value) return '';

  const cleaned = value.replace(/[^\d+]/g, '');

  if (!cleaned || cleaned.length === 0) return '';

  let result = '';
  let i = 0;

  for (let char of cleaned) {
    result += char;
    i++;

    if (i % 4 === 0 && i > 1 && i < cleaned.length) {
      result += ' ';
    }
  }

  return result;
}
}