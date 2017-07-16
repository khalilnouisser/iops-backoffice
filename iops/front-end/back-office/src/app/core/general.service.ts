import { Injectable } from '@angular/core';
import swal from 'sweetalert2';

@Injectable()
export class GeneralService {

  constructor() { }


  displayImg(urlImg){
    let htmlContent = '<div style="display: flex;justify-content: center"><img style="max-height: 90vh;margin: 20px;object-fit: contain;max-width: 450px;" src="'+urlImg+'"/></div>';
    swal({
      html:htmlContent,
      showCloseButton: false,
      showConfirmButton :false,
      showCancelButton: false,
    });
  }

}
