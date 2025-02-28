import pytest
import requests


@pytest.hookimpl(tryfirst=True)
def pytest_sessionfinish(session: pytest.Session, exitstatus: int):
    """Wird nach allen Tests aufgerufen"""

    if (session.config.option.collectonly):
        return

    if (_last_run_was_successful(session) and _run_was_successful(exitstatus)):
        requests.get("http://localhost:8989/?action=light&red=0&green=255&blue=255")
    elif (_run_was_successful(exitstatus)):
        requests.get("http://localhost:8989/?action=light&red=0&green=255&blue=0")
    else:
        requests.get("http://localhost:8989/?action=light&red=255&green=0&blue=0")

    session.config.cache.set("last_test_exitstatus", exitstatus)


def _last_run_was_successful(session: pytest.Session) -> bool:
    last_status = session.config.cache.get("last_test_exitstatus", None)

    return last_status is not None and last_status == 0


def _run_was_successful(exitstatus: int) -> bool:
    return exitstatus == 0