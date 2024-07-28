@echo off
for /d %%i in (*) do (
echo %%i && for /f "delims= " %%j in ('dir /b /a-d /s "*.pyc"') do (
del %%j
)
)
