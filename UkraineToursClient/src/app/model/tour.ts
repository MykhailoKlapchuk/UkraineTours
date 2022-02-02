import { ITourBase } from './itourbase';
import { Photo } from './photo';

export class Tour implements ITourBase {
    id: number;
    tourForm: string;
    name: string;
    tourTypeId: number;
    tourType: string;
    supportTypeId: number;
    supportType: string;
    cityId: number;
    city: string;
    price: number;
    supportPrice?: number;
    transportationPrice?: number;
    accommodationPrice?: number;
    foodPrice?: number;
    adultsOnly: boolean;
    availableFrom: string;
    photo?: string;
    description?: string;
    photos?: Photo[];
    countryPart: string;
    region: string;
    settlements?: string;
    magnets?: string;
    accomType?: string;
    duration: number;
    foodPantion?: string;
    transportType?: string;
    ownerName: string;
    ownerPhoneNumber: string;
    ownerEmail: string;
}
