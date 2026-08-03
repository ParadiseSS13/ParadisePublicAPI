# Paradise Public API

This the API for ParadiseSS13 that is publicly accessible and queryable by anyone.

## Updating EF Schemas

Run `dotnet ef dbcontext scaffold "connstring" Pomelo.EntityFrameworkCore.MySql --output-dir Database -f` with the relevant connection string. Change `Database` to `ProfilerDatabase` for the profiler DB.

## License

Paradise Public API
Copyright (C) 2021 AffectedArc07

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.