# Custom Registration fields per tenant

One of my client projects needs custom registration fields. The goal here is to make something reusable and configurable so that per tenant there can be custom registration fields. This will be a common requirement for many of my projects and I suspect it will be for many people.

### The solution provides the following

1. A configuration ([app-userproperties.json](https://github.com/joeaudette/cloudscribe.Entropy/blob/master/solutions/cloudscribe.CustomRegistration.Kvp/src/WebApp/app-userproperties.json)) based way to define custom fields per tenant for the registration page, manage user info page, and admin user edit pages so that the captured custom data can be viewed and optionally editable. It supports validation requirements per field currently supporting input, select, textarea, datepicker, and dateofbirthpicker, and read only label views. You can define custom views per property or choose from the ones already included. 

2. The captured custom data is stored in a generic key value data store that could also be reused for other purposes.

3. You can add custom form fields automatically to views based on the config file without having to manually manage all the form elements in the views. We could also if needed make custom views per tenant because of the ability to add custom views per tenant already provided in cloudscribe Core. See how we are adding custom form fields in [RegisterMiddle](https://github.com/joeaudette/cloudscribe.Entropy/blob/master/solutions/cloudscribe.CustomRegistration.Kvp/src/WebApp/Views/Account/RegisterMiddle.cshtml), [UserInfoMiddle](https://github.com/joeaudette/cloudscribe.Entropy/blob/master/solutions/cloudscribe.CustomRegistration.Kvp/src/WebApp/Views/Manage/UserInfoMiddlePartial.cshtml), and [UserEditMiddle](https://github.com/joeaudette/cloudscribe.Entropy/blob/master/solutions/cloudscribe.CustomRegistration.Kvp/src/WebApp/Views/UserAdmin/UserEditMiddlePartial.cshtml) views with very little code.

4. Custom implementations of [IHandleCustomRegistration](https://github.com/joeaudette/cloudscribe.Entropy/blob/master/solutions/cloudscribe.CustomRegistration.Kvp/src/cloudscribe.UserProperties.Web.Kvp/KvpRegistrationHandler.cs), [IHandleCustomUserInfo](https://github.com/joeaudette/cloudscribe.Entropy/blob/master/solutions/cloudscribe.CustomRegistration.Kvp/src/cloudscribe.UserProperties.Web.Kvp/KvpUserInfoHandler.cs), and [IHandleCustomUserInfoAdmin](https://github.com/joeaudette/cloudscribe.Entropy/blob/master/solutions/cloudscribe.CustomRegistration.Kvp/src/cloudscribe.UserProperties.Web.Kvp/KvpUserInfoAdminHandler.cs) interfaces from cloudscribe Core process the additional form fields

### TODO:

implement EFCore storage

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)




