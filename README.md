# Work Days Api
This Api helps you to determine if a given day is a work day on pt-BR culture or find the last/next work day based on the current day given a count of days

# Usage
If you want to calculate the workdays after the current day, use the `/after` endpoint

    GET https://workdays-api.herokuapp.com/workday/after?next_days=1

In the above example we want the 1st workday **after** today.

Also, if you want to calculate the workdays after the current day, use the `/before` endpoint

    GET https://workdays-api.herokuapp.com/workday/before?past_days=1

In the above example we want the 1st workday **before** today. 

Also if you want to calculate for a specific date, you can add the optional parameter `specific_date`

    GET https://workdays-api.herokuapp.com/workday/after?next_days=1&specific_date=2020-10-01

Both requests will return the response in `JSON` format.

    {"work_day":"2020-11-03T22:46:56.3462416+00:00"}