# BeJeweled Homework 5

- Gems now render as color emoji in console output:
  `RED -> 🔴`, `BLUE -> 🔵`, `GREEN -> 🟢`
  `YELLOW -> 🟡`, `PURPLE -> 🟣`, `ORANGE -> 🟠`
- Added two required constructors:
  - `Gem(GemType type)`
  - `GemGrid(int size)`
- Board storage uses `Gem?[][]`, where `null` means an empty cell.
- Positions are stored as simple row/column coordinates with `Position.r` and `Position.c`.
- Match detection scans rows and columns for runs of 3 or more same-type gems.
- Matches are collected as `List<List<Position>>`, one list per matched group.
- Clearing uses a `bool[,]` marker grid so overlapping matches are only removed once.
- Gravity is handled column by column by moving non-empty gems downward.
- Refill places random new gems into empty cells after gravity.
- Full cascade looping is not implemented yet; the current code provides the board operations needed for it.

## Demo Images

![Demo Image 1](<demo_image/Screenshot 2026-03-12 at 5.28.01 PM.png>)

![Demo Image 2](<demo_image/Screenshot 2026-03-12 at 5.28.15 PM.png>)
