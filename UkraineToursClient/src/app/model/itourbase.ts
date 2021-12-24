export interface ITourBase {
  id: number;
  tourForm: string;
  name: string;
  tourType: string;
  supportType: string;
  price: number;
  city: string;
  adultsOnly: boolean;
  duration: number;
  photo?: string;
  availableFrom?: string;
}
