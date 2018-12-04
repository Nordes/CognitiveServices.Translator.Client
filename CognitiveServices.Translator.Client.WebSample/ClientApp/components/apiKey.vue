<template>
  <form>
    <input type="text" class="form-control" v-model="apiKey" placeholder="Cognitives Svc Api Key">
  </form>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  data() {
    return {
      apiKey: ''
    }
  },
  watch: {
    apiKey: function (val) {
      this['translator/setCognitiveSvcKey']({cognitiveServicesKey: this.apiKey})
    }
  }, 

  methods: {
    ...mapActions(['translator/setCognitiveSvcKey']),
  }
}
</script>
