<template>
  <div class="main">
    <NavMenu />
    <RouterView
      id="content"
      class="main-content"
    />
    <CookieConsent />
  </div>
</template>

<script>
import NavMenu from 'components/navMenu'
import CookieConsent from 'components/cookieConsent'

export default {
  components: {
    'NavMenu': NavMenu,
    'CookieConsent': CookieConsent
  }
}
</script>
