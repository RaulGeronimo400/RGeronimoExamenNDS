import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

let API_URI = environment.apiUrl;


platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));

console.log(API_URI);
