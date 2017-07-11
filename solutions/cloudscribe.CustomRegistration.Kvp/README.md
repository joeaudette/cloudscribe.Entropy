# Custom Registration fields work in progress

One of my client projects needs custom registration fields. The goal here is to make something reusable and configurable so that per tenant there can be custom registration fields.

The planned solution will be as follows:

1. It will be possible to define the needed custom fields per tenant in appsettings.json - there will be a configuration based way to define custom fields per tenant for the registration page, manage user info page, and admin user edit pages so that the captured custom data can be viewed and optionally editable.

2. The captured custom data will be stored in a generic key value data store that could also be reused for other purposes.

3. We could make custom views per tenant if needed because of the ability to add custom views per tenant already provided in cloudscribe Core. There will also be a way to add per tenant custom form fields automatically based on the config file without having to manually manage all the form elements in the views.

4. Custom implementations of [IHandleCustomRegistration](https://github.com/joeaudette/cloudscribe/blob/master/src/cloudscribe.Core.Web/ExtensionPoints/IHandleCustomRegistration.cs), [IHandleCustomUserInfo](https://github.com/joeaudette/cloudscribe/blob/master/src/cloudscribe.Core.Web/ExtensionPoints/IHandleCustomUserInfo.cs), and [IHandleCustomUserInfoAdmin](https://github.com/joeaudette/cloudscribe/blob/master/src/cloudscribe.Core.Web/ExtensionPoints/IHandleCustomUserInfoAdmin.cs) will process the additional form fields



[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)




