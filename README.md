# Tic-Tac-Toe
A small console Tic-Tac-Toe game. Well, rather m,n,k, you can specify how width, height, and symbols in a row to win you want.

# Downloads & Running the Program

## Quick links
* [Windows 64-bit (Vista SP2 and later)](https://github.com/TheSheepGuy/Tic-Tac-Toe/releases/download/v1.0.0/win-x64.zip)
* [Linux 64-bit (Ubuntu 16.04 or equiv.)](https://github.com/TheSheepGuy/Tic-Tac-Toe/releases/download/v1.0.0/linux-x64.tar.gz)

## Windows

If you have the .NET Core 3 runtime installed, then [download this]. If you get an error claiming `The program can't start because [some file].dll is missing from your computer`, then you don't have the runtime installed. You can either download the [self-contained package](https://github.com/TheSheepGuy/Tic-Tac-Toe/releases/download/v1.0.0/win-x64-self-contained.zip) instead, or (which I would recommend) download the runtime by [installing the runtime](https://docs.microsoft.com/en-us/dotnet/core/install/runtime). If you are running Windows Vista SP 2, Windows 7 SP 1, or Windows 8.1 you might need to install [Microsoft Visual C++ 2015 Redistributable Update 3](https://www.microsoft.com/download/details.aspx?id=52685) and Windows Update [KB2533623](https://support.microsoft.com/help/2533623/microsoft-security-advisory-insecure-library-loading-could-allow-remot).

Once downloaded, simply run `Tic-Tac-Toe.exe` by double-clicking it.

## Linux
Similarly to Windows, if you have the .NET Core 3 runtime installed, then [download this](https://github.com/TheSheepGuy/Tic-Tac-Toe/releases/download/v1.0.0/linux-x64.tar.gz). If you get an error similar to `The required library libhostfxr.so could not be found`, then you don't have the runtime installed. Either use the [self-contained package](https://github.com/TheSheepGuy/Tic-Tac-Toe/releases/download/v1.0.0/linux-x64-self-contained.tar.gz), or install the runtime (which I would recommend),

* for Ubuntu, CentOS, and Fedora, please install dependencies by seeing [this support article](https://docs.microsoft.com/en-us/dotnet/core/install/dependencies?tabs=netcore30&pivots=os-linux#linux-distribution-dependencies). Afterwards, move to the next bullet point.

* for RHEL, Debian, OpenSUSE, SESL, and the above, go to [this support article](https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-rhel7), and use the dropdown box just below the title and date to select your distro.

* for Arch Linux, simply install the runtime using Pacman, `sudo pacman -S dotnet-runtime`. For more info, [see the wiki](https://wiki.archlinux.org/index.php/.NET_Core).

Once downloaded, mark `Tic-Tac-Toe` as an executable in the permissions properties, and then run it by opening a terminal and typing `./Tic-Tac-Toe` in the appropriate folder. *The program will not run if it's double clicked.*

# Playing the game
You can play a standard game of Tic-Tac-Toe by typing 3 for the width, height, and in-a-row to win. However, the game is a lot more fun if you type in other values, such as 5,5,4, or 7,6,5. Experiment and see which variation you like the most.

For more information, see the Wikipedia article on [m,n,k games](https://en.wikipedia.org/wiki/M,n,k-game).