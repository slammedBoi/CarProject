reason for $.ajax over .net controller
- using ajax to controller updates section of the page rather than entire page
- ex
	- if someone is watching a video and wants to do something else on the page, user would not want the entire page to update and pause their video
returns Json (or JsonResult for Razor page?) and .net returns View or like RedirectToAction()

-----------------------------------------------------------------------------------------------------------------------------

line 7: specifically removes tr elements within tbody tag in HTML element with id of carTable
$.(__).remove = removes selected HTML elements and its children elements as well
$.(__).empty = removes children elements of desired HTML element

-----------------------------------------------------------------------------------------------------------------------------