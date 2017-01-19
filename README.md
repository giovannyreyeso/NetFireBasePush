# NetFireBasePush
C# Class for send push notification to firebase 
Only send to a one target (phone)

# How to use
  Copy / Add the class to your own proyect
# How to send push
  First you need have a token from your proyect in firebase
# Example
	1) Create a Object "FireBasePush" with your token proyect (from firebase proyect):
```c#
FireBasePush push = new FireBasePush("token_here");
```
	2) Call the method SendPush:
```c#
push.SendPush(new PushMessage
{
	to = "token_target",
	notification = new PushMessageData
	{
		title = "title push",
		text = "body text",
		click_action = click_action
	},
	data = new
	{
		example = "ey this is a example" 
	}
});
```
	3) data is optional and only send "extra data" in push:
  
