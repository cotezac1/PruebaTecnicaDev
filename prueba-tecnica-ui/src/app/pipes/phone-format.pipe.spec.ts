import { PhoneFormatPipe } from './phone-format.pipe';

describe('PhoneFormatPipe', () => {
  let pipe: PhoneFormatPipe;

  beforeEach(() => {
    pipe = new PhoneFormatPipe();
  });

  it('should create an instance', () => {
    expect(pipe).toBeTruthy();
  });

it('should format "+56912345678" to "+569 1234 5678"', () => {
  const result = pipe.transform('+56912345678');
  expect(result).toBe('+569 1234 5678');
});
  it('should return empty string if value is null or undefined', () => {
    expect(pipe.transform(null as any)).toBe('');
    expect(pipe.transform(undefined as any)).toBe('');
  });
});