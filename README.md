<h1>Unit Converter: Gamified Edition (Godot 4.6)</h1>

<p>A cross-platform unit conversion application built with C# and the Godot Engine. Originally intended as an AutoCAD plugin for CAD work, this version adds a layer of gamification and high-fidelity UI to make repetitive engineering tasks more engaging.</p>

<img width="360" height="480" alt="mainscreendefault" src="https://github.com/user-attachments/assets/d9ab7e3b-3c64-4677-9bdd-41bb66fb3b81" />
<img width="360" height="480" alt="settingscreendefault" src="https://github.com/user-attachments/assets/f824e72a-1ed1-4d12-b3e4-add715d85d42" />

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

<section id="how-to-run">
<h2>How to Run</h2>
<p>To run this project from source, you will need the <strong>Godot Engine - .NET Edition</strong> and the <strong>.NET SDK</strong>.</p>

<h3>1. Prerequisites</h3>
<ul>
<li><strong>Godot 4.6 (Standard + .NET):</strong> Ensure you download the .NET version of Godot from the <a href="https://godotengine.org/download" target="_blank">official site</a>.</li>
<li><strong>.NET SDK:</strong> You must have the .NET SDK (8.0 or newer recommended) installed on your system for the C# code to compile.</li>
</ul>

<h3>2. Installation</h3>
<ol>
<li>Clone the repository:<br>
<code>git clone https://github.com/YourUsername/YourRepoName.git</code></li>
<li>Open the Godot Engine launcher.</li>
<li>Click <strong>Import</strong>, navigate to the cloned folder, and select the <code>project.godot</code> file.</li>
</ol>

<h3>3. Building and Running</h3>
<ol>
<li>Once the project is open in the editor, click the <strong>Build</strong> button (the hammer icon in the top-right corner). This compiles the <code>.sln</code> and <code>.csproj</code> files.</li>
<li>After the build completes, press <strong>F5</strong> or the <strong>Play</strong> button to launch the application.</li>
</ol>
</section>
