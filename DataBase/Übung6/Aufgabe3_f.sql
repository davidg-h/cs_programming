select * from Kunden
where Land = "Deutschland" and
plz like "9%" or plz like "8%"
order by firma asc