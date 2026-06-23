<h1>Unit Converter: Gamified Edition (Godot 4.6)</h1>

<p>A cross-platform unit conversion application built with C# and the Godot Engine. Originally intended as an AutoCAD plugin for CAD work, this version adds a layer of gamification and high-fidelity UI to make repetitive engineering tasks more engaging.</p>

<h2>Key Features</h2>

<ul>
  <li><b>Multi-Unit Engine:</b> Perform conversions across Distance (including fractional architectural formats), Weight, Pressure, and Flow Rates using a centralized base-unit architecture.</li>
  <li><b>Gamified HUD:</b></li>
  <ul>
    <li><b>Health Bar:</b> Tracks input errors; don't let your "health" reach zero by entering invalid formats!</li>
    <li><b>Experience & Levels:</b> Earn "XP" for successful conversions.</li>
    <li><b>High Score:</b> Persistent tracking of total conversions performed over the lifetime of the app.</li>
  </ul>
  <li><b>Advanced Audio & Visuals:</b></li>
  <ul>
    <li><b>Theme Engine:</b> Toggle between different visual "skins" to match your workspace.</li>
    <li><b>Dynamic Audio:</b> A selection of background music and separate volume sliders for Music, UI clicks, and Special Effects.</li>
    <li><b>Easter Eggs:</b> Keep an eye out for unique responses to "special" input values.</li>
  </ul>
</ul>

<h2>Technical Details</h2>
<ul>
  <li><b>Framework:</b> C# .NET integration within Godot 4.6.</li>
  <li><b>Input Handling:</b> Custom re (Regex) patterns to parse complex architectural strings (e.g., 5'-2 1/2").</li>
  <li><b>Architecture:</b> Decoupled UI and Logic, allowing for easy expansion of the unit dictionaries.</li>
  <li><b>Persistence:</b> Settings, high scores, and theme preferences are saved locally between sessions.</li>
</ul>

<h2>Future Roadmap</h2>
<ul>
  <li><b>Temperature Module:</b> Integration of offset-based scales (Celsius, Fahrenheit, Kelvin).</li>
  <li><b>Force & Linear Density:</b> Adding Newtons per meter and lbs per foot for structural analysis.</li>
  <li><b>Expanded Gamification:</b> More "sassy" messages and visual rewards for power users.</li>
</ul>
