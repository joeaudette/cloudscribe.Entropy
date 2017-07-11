# Custom Registration fields per tenant

One of my client projects needs custom registration fields. The goal here is to make something reusable and configurable so that per tenant there can be custom registration fields. This will be a common requirement for many of my projects and I suspect it will be for many people.

### The solution provides the following

1. It is possible to define the needed custom fields per tenant in [appsettings.json](https://github.com/joeaudette/cloudscribe.Entropy/blob/master/solutions/cloudscribe.CustomRegistration.Kvp/src/WebApp/appsettings.json) - a configuration based way to define custom fields per tenant for the registration page, manage user info page, and admin user edit pages so that the captured custom data can be viewed and optionally editable. It supports validation requirements per field currently supporting input, select, textarea, datepicker, and dateofbirthpicker, and read only label views. You can define custom views per property or choose from the ones already included. 

2. The captured custom data is stored in a generic key value data store that could also be reused for other purposes.

3. We could make custom views per tenant if needed because of the ability to add custom views per tenant already provided in cloudscribe Core. There is also a way to add per tenant custom form fields automatically based on the config file without having to manually manage all the form elements in the views.

4. Custom implementations of [IHandleCustomRegistration](https://github.com/joeaudette/cloudscribe/blob/master/src/cloudscribe.Core.Web/ExtensionPoints/IHandleCustomRegistration.cs), [IHandleCustomUserInfo](https://github.com/joeaudette/cloudscribe/blob/master/src/cloudscribe.Core.Web/ExtensionPoints/IHandleCustomUserInfo.cs), and [IHandleCustomUserInfoAdmin](https://github.com/joeaudette/cloudscribe/blob/master/src/cloudscribe.Core.Web/ExtensionPoints/IHandleCustomUserInfoAdmin.cs) will process the additional form fields

### TODO:

implement EFCore storage

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)




