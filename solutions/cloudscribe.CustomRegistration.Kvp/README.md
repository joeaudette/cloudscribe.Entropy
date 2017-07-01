# Custom Registration fields work in progress

One of my client projects needs custom registration fields. The goal here is to make something reusable and configurable so that per tenant there can be custom registration fields.

The planned solution will be as follows:

1. Take advantage of the ability to add custom views per theme to make a custom Register.cshtml per tenant in the tenant theme folder. This will enable adding the custom inputs right in the view.

2. a custom implementation of [IHandleCustomRegistration](https://github.com/joeaudette/cloudscribe/blob/master/src/cloudscribe.Core.Web/ExtensionPoints/IHandleCustomRegistration.cs) will process the additional form fields

3. it will be possible to define the needed custom fields per tenant in appsettings.json

4. The captured custom data will be stored in a generic key value data store 

5. We may need a custom controller and views for viewing or updating the custom data after registration

The plan is for the custom key/value storage and the custom IHandleCustomRegistration to be reusable.

The secondary work for viewing the captured data may be per project customization depending on what we come up with.

[![Join the chat at https://gitter.im/joeaudette/cloudscribe](https://badges.gitter.im/joeaudette/cloudscribe.svg)](https://gitter.im/joeaudette/cloudscribe?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)




