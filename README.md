#  Tempo Detector: A WPF Digital Metronome and Tempo Detector

##  Project Description

This is a **C# WPF application** designed to act as a responsive digital metronome.

It calculates the precise **Beats Per Minute (BPM)** by recording the time intervals between a user's taps. To ensure the tempo is stable yet responsive, it utilizes a rolling average of the last few inputs. The core feature is its **visual feedback** mechanism: a dedicated on-screen indicator that begins to flash in perfect sync with the detected tempo once the user stops tapping.

##  Key Features

* **Real-Time BPM Calculation:** Dynamically determines the tempo based on the time between clicks.
* **Rolling Average:** Uses a stable calculation (currently set to the last 4 taps) to prevent single-click outliers from skewing the BPM too severely.
* **Visual Metronome:** The indicator box is controlled by a `DispatcherTimer`, precisely flashing at the calculated interval to provide rhythmic feedback.
* **Responsive WPF UI:** Clean and simple interface for focused use.
* **Instant Reset:** Dedicated button to clear tap history and stop the visual metronome instantly.

##  Technology Stack

* **Language:** C#
* **Framework:** .NET Framework (WPF - Windows Presentation Foundation)
* **Development Environment:** Visual Studio

##  Getting Started

To build and run this project, you will need **Visual Studio** installed on a Windows machine.

### Prerequisites

* **Visual Studio 2019 or later:** Ensure you have the **".NET desktop development"** workload installed.
* **Target Framework:** The project is configured to run on a common version of the .NET Framework (e.g., 4.8).

### Installation and Build Instructions

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com/YourUsername/Tempo-Detector.git
    ```
    *(Remember to update the username in the command above!)*

2.  **Open the Solution:**
    * Locate and double-click the `.sln` (Solution) file to open the project in Visual Studio.

3.  **Run the Application:**
    * In Visual Studio, select **Start** (or press `F5`). This will compile and launch the application window.

##  How to Use the App

1.  **Tap the Beat:** Click the large **"Tap Here"** button repeatedly in time with the tempo you wish to measure.
2.  **BPM Display:** The BPM value updates instantly on the display area.
3.  **Activate Metronome:** **Stop clicking.** After a brief pause, the indicator box will start flashing at the determined tempo, acting as your visual metronome.
4.  **Clear:** Click the **"Reset"** button to clear the tap history and instantly stop the flashing indicator.
