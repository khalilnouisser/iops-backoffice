import { Injectable } from '@angular/core';

@Injectable()
export class DateService {

  constructor() { }

  date_diff(d2: Date) {
    let d1 = new Date();

    let diff = (d1.valueOf() - d2.valueOf()) / 1000;

    let day_diff = Math.floor(diff / 86400);

    /*if ( isNaN(day_diff) || day_diff < 0 || day_diff > 31 ) {
     console.log("no !");
     return;
     }*/

    return day_diff == 0 && (
      diff < 60 && "Maintenant" ||
      diff < 120 && "Il y a 1 minute" ||
      diff < 3600 && "Il y a" + Math.floor(diff / 60) + " minutes" ||
      diff < 7200 && "Il a 1 heure" ||
      diff < 86400 && "Il y a " + Math.floor(diff / 3600) + " heures") ||
      day_diff == 1 && "Hier" || day_diff == 31 && "Il y a 1 mois" ||
      day_diff < 7 && "Il y a " + day_diff + " jours" ||
      day_diff < 31 && "Il y a " + Math.ceil(day_diff / 7) + " semaines" ||
      day_diff > 31 && "Il y a 2 mois";

  }


}
