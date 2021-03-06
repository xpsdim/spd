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
import { ChangePasswordFormComponent } from './profile/change-password/change-pass.component';
import { ProfileModule } from './profile/profile.module';
import { ApiRequestOptions } from './shared/utils/api.request.options';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,    
    ChangePasswordFormComponent    
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
      { path: 'profile', component: ChangePasswordFormComponent }      
    ])
  ],
  providers: [HttpClientModule,
    {
      provide: RequestOptions,
      useClass: ApiRequestOptions
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
