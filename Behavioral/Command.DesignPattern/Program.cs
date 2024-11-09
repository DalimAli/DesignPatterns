using Command.DesignPattern;

Light light = new Light();
ICommand turnOnCommand = new TurnOnCommand(light);
ICommand turnOffCommand = new TurnOffCommand(light);

turnOnCommand.Execute(); // Output: The light is on.
turnOffCommand.Execute(); // Output: The light is off.