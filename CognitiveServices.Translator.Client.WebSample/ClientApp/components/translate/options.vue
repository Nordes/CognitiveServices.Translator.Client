<template>
  <div>
    <form>
      <div class="form-group row">
        <!-- TypeText -> ddl [default plain] or html -->
        <label for="typeText" class="col-sm-4 col-form-label">Input type</label>
        <div class="col-sm-8">
          <select class="form-control" v-model="typeText" id="typeText">
            <option value="plain" selected="selected">plain (default)</option>
            <option value="html">html</option>
          </select>
        </div>
      </div>

      <div class="form-group row">
        <label for="from" class="col-sm-4 col-form-label">From</label>
        <div class="col-sm-8">
          <input type="text" class="form-control" v-model="from" id="from" placeholder="i.e.: en">
        </div>
      </div>
      <div class="form-group row">
        <label for="suggestedFrom" class="col-sm-4 col-form-label">From (Suggested)</label>
        <div class="col-sm-8">
          <input type="text" class="form-control" v-model="fromSuggested" id="suggestedFrom" placeholder="i.e.: en">
        </div>
      </div>

      <div class="form-group row">
        <label for="to" class="col-sm-4 col-form-label">To*</label>
        <div class="col-sm-8">
          <input type="text" class="form-control" v-model="to" id="to" placeholder="i.e.: fr,es">
        </div>
      </div>

      <div class="form-group row">
        <!-- ProfanityAction -->
        <label for="profanityAction" class="col-sm-4 col-form-label">Profanity action</label>
        <div class="col-sm-8">
          <select class="form-control" v-model="profanityAction" id="profanityAction">
            <option value="NoAction" selected="selected">No action (default)</option>
            <option value="Marked">Marked</option>
            <option value="Deleted">Deleted</option>
          </select>
        </div>
      </div>

      <div class="form-group row">
        <label for="category" class="col-sm-4 col-form-label">Category</label>
        <div class="col-sm-8">
          <input type="text" class="form-control" v-model="category" id="category" placeholder="Default: general">
        </div>
      </div>

      <div class="form-group row">
        <!-- ProfanityMarker -->
        <label for="profanityMarker" class="col-sm-4 col-form-label">Profanity marker</label>
        <div class="col-sm-8">
          <select class="form-control" v-model="profanityMarker" id="profanityMarker">
            <option value="Asterisk" selected="selected">Asterisk (default)</option>
            <option value="Tag">Tag</option>
          </select>
        </div>
      </div>

      <div class="form-group row">
        <div class="form-check ml-3 mt-2">
          <input class="form-check-input" type="checkbox" v-model="includeAlignment" id="includeAlignment">
          <label class="form-check-label" for="includeAlignment">
            Include alignment
          </label>
        </div>
      </div> <!-- End form-check -->

      <div class="form-group row">
        <div class="form-check ml-3 mt-2">
          <input class="form-check-input" type="checkbox" v-model="includeSentenceLength" id="includeSentenceLength">
          <label class="form-check-label" for="includeSentenceLength">
            Include sentence length
          </label>
        </div> <!-- End form-check -->
      </div>

      <div class="form-group row">
        <label for="fromScript" class="col-sm-4 col-form-label">From script</label>
        <div class="col-sm-8">
          <input type="text" class="form-control" v-model="fromScript" id="fromScript" placeholder="RTM">
        </div>
      </div>

      <div class="form-group row">
        <label for="toScript" class="col-sm-4 col-form-label">To script</label>
        <div class="col-sm-8">
          <input type="text" class="form-control" v-model="toScript" id="toScript" placeholder="RTM">
        </div>
      </div>
    </form>
  </div>
</template>

<script>
import { mapActions } from 'vuex'

export default {
  watch: {
    typeText: function (val) {
      this.setTranslateType({translateType: this.typeText});
    }
  },
  data() {
    return {
      typeText: 'plain',
      from: 'en',
      fromSuggested: '',
      to: 'ja',
      profanityAction: 'NoAction',
      category: 'general',
      profanityMarker: 'Asterisk',
      includeAlignment: false,
      includeSentenceLength: false,
      fromScript: null,
      toScript: null
    }
  },

  methods: {
    ...mapActions(['setTranslateType']),

    getData: function () {
      var options = {
        typeText: this.typeText,
        from: this.from,
        fromSuggested: this.fromSuggested,
        to: this.to.split(','),
        profanityAction: this.profanityAction,
        category: this.category,
        profanityMarker: this.profanityMarker,
        includeAlignment: this.includeAlignment,
        includeSentenceLength: this.includeSentenceLength,
        fromScript: this.fromScript,
        toScript: this.toScript
      }

      return options;
    }
  }
}
</script>
