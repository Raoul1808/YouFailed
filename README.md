# You Failed!
 This is the source code for **You Failed!**, a very dumb SRXD mod that shuts down your computer when you fail a song or try to escape the apocalypse.
 
# How it works
 Upon failing, restarting or leaving a song, the mod will [start a thread](https://github.com/Raoul1808/YouFailed/blob/044a7bd8e13a1ca8b9646099a7607d9d5332dfd3/Main.cs#L95) that will [cycle through multiple commands to run](https://github.com/Raoul1808/YouFailed/blob/044a7bd8e13a1ca8b9646099a7607d9d5332dfd3/Main.cs#L20).
 
 The PC then [shuts down 10 seconds later](https://github.com/Raoul1808/YouFailed/blob/044a7bd8e13a1ca8b9646099a7607d9d5332dfd3/Main.cs#L104).
 
# How to defuse
 Assuming you have a powerful enough PC to open cmd or anything to run commands, you can type `shutdown /a` to cancel the shutdown. Windows will still keep on popping up until the game closes or crashes.
 
# How to build
 [I've made a guide for that](https://github.com/Raoul1808/SpeenChroma/wiki/Building-the-mod), just make sure you [match the dependencies with what the mod actually requires](https://github.com/Raoul1808/YouFailed/blob/044a7bd8e13a1ca8b9646099a7607d9d5332dfd3/YouFailed.csproj#L38) (it doesn't require \*everything\* listed on the building guide)
 
# Why?
 [Blame soda, edge and haomakk](https://discord.com/channels/638508804505337867/776845579812601896/916398507995303936).
 
 Oh and me too for the free rickroll and baby shark (I didn't watch it, but it sounds annoying)
