import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RequestOptions } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AccountModule } from './account/account.module';
import { HttpModule } from '@angular/http';
import { ProfileFormComponent } from './profile-form/profile-form.component';
import { ProfileModule } from './profile-form/profile-form.module';
import { AuthRequestOptions } from './shared/utils/auth.request.options';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,    
    ProfileFormComponent    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    AccountModule,
    ProfileModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'profile', component: ProfileFormComponent }      
    ])
  ],
  providers: [HttpClientModule,
    {
      provide: RequestOptions,
      useClass: AuthRequestOptions
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
